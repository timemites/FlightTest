import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms'
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { interval } from "rxjs";
import { FlightService } from '../shared/flight.service';
import { Flight } from '../shared/flight.model';

import { BookingService } from '../shared/booking.service';
import { Booking } from '../shared/booking.model';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html'
})
export class FlightsComponent implements OnInit {

  flightList: Flight[];
  flightDetail: Flight;
  passenger: number;
  flight: number;

  passengerCapacity: number;
  selectedFlight: string;
  travelDate: Date;
  bookingNo: number;

  bookings: Booking[] = [];

  bookingDetail: Booking = {
    FlightId: 0,
    BookingRefNo:'',
    FlightName:'',
    BookingDate: this.travelDate,
    FirstName: '',
    LastName: '',
    Email: ''

  };
  bookingDetail2: Booking = {
    FlightId: 0,
    FlightName:'',
    BookingRefNo:'',
    BookingDate: this.travelDate,
    FirstName: '',
    LastName: '',
    Email: ''

  };
  //Form Components

  FirstName1: string = "";
  LastName1: string = "";
  Email1: string = "";

  FirstName2: string = "";
  LastName2: string = "";
  Email2: string = "";

  bookingConfirmed: boolean;
  public loading = false;

  constructor(private flightService: FlightService, private bookingService: BookingService, private frmBuilder: FormBuilder) { }

  ngOnInit() {
    //Form Styling


    this.passenger = undefined;

    this.flightService.getFlights();
    this.flightList = this.flightService.flightList;
  }


  //Check Flight Availability
  getAvailability() {

    if (this.passenger == undefined) {
      this.passenger = 1;
    }

    this.loading=true
    //console.log(this.passenger);

    this.flightService.getAvailability(this.flight, this.travelDate, this.passenger)
    .subscribe(data =>{
         this.passengerCapacity=data
    })
    this.loading=false
    
  }
  formValid() {
    if (this.flight == undefined || this.travelDate == undefined || this.bookingConfirmed) {
      return true;
    }
    else {
      return false;
    }
  }
  bookingFormInvalid() {
    if (this.passenger > 1) 
    {
      if (this.FirstName1 == "" || this.LastName1 == "" || this.Email1 == ""||
      this.FirstName2 == "" || this.LastName2 == "" || this.Email2 == "") 
      {
     
        return true;
      }
      else {
        return false;
      }
     
    }
    else {
      if (this.FirstName1 == "" || this.LastName1 == "" || this.Email1 == "")
      {
        return true;
      }
      else{
        return false
      }

    }
   
  }
  setSelectedStatus(value: number): void {
    // console.log(this.flightService.flightList);
    this.flightDetail = this.flightService.flightList.find(s => s.FlightId == value);
    this.selectedFlight = this.flightDetail.ArrivalCity;
  }

  postBooking() {

    this.loading = true;
   
    this.bookings = [];
    this.flight = this.flightDetail.FlightId
    //console.log("post Booking");
    if (this.passenger > 1) {

      this.bookingDetail.BookingDate = this.travelDate;
      this.bookingDetail.FlightId = this.flight;
      this.bookingDetail.FlightName = this.selectedFlight;
      this.bookingDetail.FlightName = this.selectedFlight;
      this.bookingDetail.FirstName = this.FirstName1;
      this.bookingDetail.LastName = this.LastName1;
      this.bookingDetail.Email = this.Email1;
      console.log(this.bookingDetail);
      this.bookings.push(this.bookingDetail);

      this.bookingDetail2.BookingDate = this.travelDate;
      this.bookingDetail2.FlightId = this.flight;
      this.bookingDetail.FlightName = this.selectedFlight;
      this.bookingDetail2.FirstName = this.FirstName2;
      this.bookingDetail2.LastName = this.LastName2;
      this.bookingDetail2.Email = this.Email2;
      console.log(this.bookingDetail2);
      this.bookings.push(this.bookingDetail2);

    }
    else {
      this.bookingDetail.BookingDate = this.travelDate;
      this.bookingDetail.FlightId = this.flight;
      this.bookingDetail.FlightName = this.selectedFlight;
      this.bookingDetail.FirstName = this.FirstName1;
      this.bookingDetail.LastName = this.LastName1;
      this.bookingDetail.Email = this.Email1;
      console.log(this.bookingDetail);

      this.bookings.push(this.bookingDetail);

    }

    this.bookingService.postBooking(this.bookings)
      .subscribe(res => {
        this.loading = false;
        //...
      }, err => {
        this.loading = false;
        console.log(err);
        //...
      });
    this.bookingConfirmed = Object.assign({}, this.bookingService.bookingConfirmed);

  }
  //END POST


}
