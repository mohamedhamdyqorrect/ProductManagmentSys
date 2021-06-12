

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using static Product.Core.ServiceResult;

namespace ProductApi.Controllers.Shared
{
    [Route("")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Get result with status code based on model errors
        /// </summary>
        /// <typeparam name="T">type of result</typeparam>
        /// <param name="result">result</param>
        /// <returns>action result</returns>
        protected IActionResult GetErrorResult<T>(IServiceResult<T> result) where T : class
        {
            if (result == null)
            {
                return StatusCode(500);
            }
            //if (result.Status == ValidationStatus.NotFound)
            //{
            //    return StatusCode(404);
            //}
            //if (result.Status == ValidationStatus.Accepted)
            //{
            //    // request accepted but still in processing https://restfulapi.net/http-status-202-accepted/
            //    return StatusCode(202, new { messages = result.Messages });
            //}
            foreach (string message in result.Messages)
            {
                ModelState.AddModelError("errors", message);
            }
            if (ModelState.IsValid)
            {
                // No ModelState errors are available to send, so just return an empty BadRequest.
                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Check result, and get response
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IActionResult GetApiResponse<TResult>(ServiceResultList<TResult> result) where TResult : class
        {
            if (result.IsValid)
            {
                return Ok(result.Model);
            }
            return GetErrorResult(result);
        }

        /// <summary>
        /// Check detail result, and get response
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IActionResult GetApiResponse<TResult>(ServiceResultDetail<TResult> result) where TResult : class
        {
            if (result.IsValid)
            {
                return Ok(result.Model);
            }
            return GetErrorResult(result);
        }

        /// <summary>
        /// Check result, set paging header, and get response
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="result"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="pagingRouteName"></param>
        /// <param name="pagingRouteData"></param>
        /// <returns></returns>
        protected IActionResult GetApiResponse<TResult>(ServiceResultList<TResult> result, int page, int pageSize) where TResult : class
        {
            if (result.IsValid)
            {
                SetPaginationHeader(page, pageSize, result.Count);

                return Ok(result.Model);
            }
            return GetErrorResult(result);
        }

        /// <summary>
        /// Check detail result, set paging header, and get response
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="result"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="pagingRouteName"></param>
        /// <param name="pagingRouteData"></param>
        /// <returns></returns>
        protected IActionResult GetApiResponse<TResult>(ServiceResultDetail<TResult> result, int page, int pageSize) where TResult : class
        {
            if (result.IsValid)
            {
                SetPaginationHeader(page, pageSize, result.SubTotalCount);

                return Ok(result.Model);
            }
            return GetErrorResult(result);
        }


        #region Private helpers
        /// <summary>
        /// Prepare and Set the X-Pagination Header to the Response
        /// </summary>
        /// <param name="page">current page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="totalCount">total count</param>
        private void SetPaginationHeader(int page, int pageSize, long totalCount)
        {
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginationHeader = new
            {
                currentPage = page,
                pageSize,
                totalCount,
                totalPages
            };

            Response.Headers.Add("X-Pagination",
            JsonConvert.SerializeObject(paginationHeader));
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");
        }
        #endregion
    }
}
