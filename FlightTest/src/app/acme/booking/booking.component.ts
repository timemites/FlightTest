import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms'
import {MatPaginator, MatSort, MatTableDataSource} from '@angular/material';
import { BookingService } from '../shared/booking.service';
import { Booking } from '../shared/booking.model';
import {DataSource} from '@angular/cdk/collections';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html'
})
export class BookingComponent implements OnInit {
  displayedColumns = ['BookingRefNo', 'BookingDate', 'ArrivalCity', 'FirstName', 'LastName'];
   
  dataSource;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  
  constructor(private bookingService: BookingService) { 
   
  }
  
  ngOnInit() {
   
    this.bookingService.getBookings().subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
    
    });
   
  }
 
  applyFilter(filterValue: string) {
    console.log("in filter");
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }


}

