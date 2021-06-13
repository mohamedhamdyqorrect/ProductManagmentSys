import { Component, OnInit } from '@angular/core';
import {ProductDetailService} from 'src/app/Products/shared/Product-detail.service'
import { ProductDetail } from './../../Products/shared/product-detail.model';

import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styles: [
  ]
})
export class ListProductsComponent implements OnInit {

  constructor(private toastr: ToastrService,private router: Router,public service: ProductDetailService) { }
  ngOnInit(): void {
    this.service.refreshList();
    
  }
  populateForm(selectedRecord: any) {
    console.log(selectedRecord);
    if (selectedRecord) {
      this.router.navigate(['product/', selectedRecord]);
    }
   // this.service.formData = Object.assign({}, selectedRecord);
  }
  onDelete(PMId: any) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deleteProductDetail(PMId)
        .subscribe(res => {
          this.toastr.success('Deleted successfully', 'Products');
          this.service.refreshList();
        },
        err => { console.log(err); })
    }
  }
  AddItem() {
    this.router.navigate(['product']);
  }
}

