import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { NgForm } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { OrderItemsComponent } from '../order-items/order-items.component';
import { Customer } from 'src/app/shared/customer.model';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { CustomerService } from './../../shared/customer.service';
import { OrderService } from './../../shared/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styles: []
})
export class OrderComponent implements OnInit {

  userDetails:any;
  customerList: Customer[];
  isValid: boolean = true;

  constructor(private router:Router, private userService:UserService,private orderService: OrderService,
    private dialog: MatDialog,private customerService: CustomerService, private toastr: ToastrService, 
    private currentRoute: ActivatedRoute) { }

  ngOnInit() {
    // We are interecepting the http request and response and checking if the details exist
    this.userService.getUserDetails().subscribe(
      res =>{
        this.userDetails = res;

        let orderID = this.currentRoute.snapshot.paramMap.get('id');
    if (orderID == null)
      this.resetForm();
    else {
      this.orderService.getOrderByID(parseInt(orderID)).then(res => {
        this.orderService.formData = res.order;
        this.orderService.orderItems = res.orderDetails;
      });
    }

    this.customerService.getCustomerList().then(res => this.customerList = res as Customer[]);
    document.querySelector('body').classList.add('login');
    
      },
      err =>{
        if(err.status == 401) {
          localStorage.removeItem('token');
          this.router.navigateByUrl('/user/login');
        }
      }
    )

    let orderID = this.currentRoute.snapshot.paramMap.get('id');
    if (orderID == null)
      this.resetForm();
    else {
      this.orderService.getOrderByID(parseInt(orderID)).then(res => {
        this.orderService.formData = res.order;
        this.orderService.orderItems = res.orderDetails;
      });
    }

    this.customerService.getCustomerList().then(res => this.customerList = res as Customer[]);
    
  }

  resetForm(form?: NgForm) {
    if (form = null)
      form.resetForm();
    this.orderService.formData = {
      OrderID: null,
      OrderNo: Math.floor(100000 + Math.random() * 900000).toString(),
      CustomerID: 0,
      PMethod: '',
      GTotal: 0,
      DeletedOrderItemIDs: ''
    };
    this.orderService.orderItems = [];
  }

  AddOrEditOrderItem(orderItemIndex, OrderID) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "50%";
    dialogConfig.data = { orderItemIndex, OrderID };
    this.dialog.open(OrderItemsComponent, dialogConfig).afterClosed().subscribe(res => {
      this.updateGrandTotal();
    });
  }


  onDeleteOrderItem(orderItemID: number, i: number) {
    if (orderItemID != null)
      this.orderService.formData.DeletedOrderItemIDs += orderItemID + ",";
    this.orderService.orderItems.splice(i, 1);
    this.updateGrandTotal();
  }

  updateGrandTotal() {
    this.orderService.formData.GTotal = this.orderService.orderItems.reduce((prev, curr) => {
      return prev + curr.Total;
    }, 0);
    this.orderService.formData.GTotal = parseFloat(this.orderService.formData.GTotal.toFixed(2));
  }

  validateForm() {
    this.isValid = true;
    if (this.orderService.formData.CustomerID == 0)
      this.isValid = false;
    else if (this.orderService.orderItems.length == 0)
      this.isValid = false;
    return this.isValid;
  }


  onSubmit(form: NgForm) {
    if (this.validateForm()) {
      this.orderService.saveOrUpdateOrder().subscribe(res => {
        this.resetForm();
        this.toastr.success('Submitted Successfully', 'Restaurent App.');
        this.router.navigate(['/orders']);
      })
    }
  }



  onLogout() {
    localStorage.removeItem('token');
    document.querySelector('body').classList.remove('login');
    this.router.navigateByUrl('/user/login');

  }



}

