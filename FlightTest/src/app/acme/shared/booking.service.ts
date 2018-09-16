import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders  } from '@angular/common/http'
import { Observable } from 'rxjs'
import { Booking } from './booking.model'
import { Flight } from './flight.model'

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  flight: Flight;
  bookingList:Booking[];
  bookingCount: number;
  flightId: number;
  passengerCount: number;
  flightDate: Date;
  bookingNo: number;
  bookingConfirmed: boolean;

  constructor(private _http: HttpClient) { }
  getBookings(){
    return this._http.get<Booking[]>('http://localhost:63395/api/ManageBooking')
    
  }
  getBookingNo(): Observable<number> {
    return this._http.get<number>('http://localhost:63395/api/Booking')

  }
  postBooking(books: Booking[]) {

    var body = JSON.stringify(books);
   
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
   // console.log(books);
    this.bookingConfirmed = true;
    return this._http.post('http://localhost:63395/api/Booking?', body, httpOptions)
     
    
  }
}
