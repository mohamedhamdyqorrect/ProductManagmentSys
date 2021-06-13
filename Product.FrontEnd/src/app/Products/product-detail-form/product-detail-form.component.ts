import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import {ProductDetailService} from 'src/app/Products/shared/Product-detail.service'
import {ProductDetail} from 'src/app/Products/shared/product-detail.model'
import { ToastrService } from 'ngx-toastr';
import { ProductTypes } from '../shared/productTypes.model';
@Component({
  selector: 'app-product-detail-form',
  templateUrl: './product-detail-form.component.html',
  styles: [
  ]
})
export class ProductDetailFormComponent implements OnInit {

  constructor(private toastr: ToastrService,
   public service: ProductDetailService,
   private router: Router,
    private activateRoute: ActivatedRoute) { }
     formData: ProductDetail=new ProductDetail();
    // title = 'Add New Product';
    urlImage='';
    PrdTypes: ProductTypes[]= [ {title:'Food',productTypeId:1},
     {title:'Electronics',productTypeId:2},
  {title:'Clothes',productTypeId:3}];

  // PrdTypes: { id: number, name: string }[] = [
  //     { "id": 0, "name": "Available" },
  //     { "id": 1, "name": "Ready" },
  //     { "id": 2, "name": "Started" }
  // ];
    
  //PrdTypes = ['Food', 'Electronics', 'Clothes'];
    id=0;
  ngOnInit(): void {
    this.id = 0;
    this.activateRoute.paramMap.subscribe(param => {
      var id = Number( param.get('id'));
      if (id) {
        this.id = id as number;
        this.service.GetProductByID(id).subscribe(prod => {
          console.log(prod);
         // this.title = 'Update Product Data';
          this.id = id;
         
         // alert(JSON.stringify(this.selectedItems));
         this.formData.productDetailId=prod.productDetailId;
         this.formData.quantity=prod.quantity;
         this.formData.title=prod.title;
         this.formData.unitPrice=prod.unitPrice;
         this.formData.discountPercent=prod.discountPercent;
         this.formData.productTypeID=prod.productTypeID;
         this.formData.imageUrl=prod.imageUrl;
          console.log(prod.imageUrl);
         // if(prod.imageUrl !=null && prod.imageUrl!=''){
          //this.urlImage = AppComponent.apiURL+'images/articles/' + prod.imageUrl;}
          // fetch(this.urlImage).then(res => res.blob()).then(blob => {
          //   var file = new File([blob], actor.mainImage);
          //   this.img = file;
          //   console.log(actor.mainImage);
          // })
        }, ex => {
          console.log(ex);
        })
      }
   })
  }
  resetForm(form: NgForm) {
    form.form.reset();
    this.formData = new ProductDetail();
  }
  onSubmit(form: NgForm) {
    this.formData.productTypeID=Number(this.formData.productTypeID);
    if (this.formData.productDetailId == 0)
    this.insertRecord(form);
  else
    this.updateRecord(form);
  }
  insertRecord(form: NgForm) {
  
     console.log('insertRecord',this.formData);
    this.service.postProductDetail(this.formData).subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Inserted successfully', 'Product Details');
        setTimeout(() => {
        this.router.navigate(['products']);
      }, 1000);  //1s
      },
      err => { console.log(err); }
    )
  }
  updateRecord(form: NgForm) {
    console.log('updateRecord',this.formData);
    this.service.putProductDetail(this.formData).subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated successfully', 'Product Details')
        setTimeout(() => {
          this.router.navigate(['products']);
        }, 1000);  //1s
      },
      err => { console.log(err); }
    );
  }

}
