
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'

import {Flight} from './flight.model'
@Injectable({
  providedIn: 'root'
})
export class FlightService {
  selectedFlight:Flight;
flightList:Flight[];
flight:Flight;
bookingCount:number;
flightId:number;
passengerCount:number;
flightDate:Date;
  constructor(private _http:HttpClient) { }

  getFlights(){
    this._http.get<Flight[]>('http://localhost:63395/api/Flights')
    .subscribe(data =>{
      this.flightList=data
      
    })
  }

  getAvailability(flightId,flightDate,passengerCount){
    if (passengerCount=undefined || passengerCount==0){
      passengerCount=1;
    }
     
    return this._http.get<number>('http://localhost:63395/api/Availability?flightId='+ flightId + "&flightDate=" + flightDate + "&passenger=" + passengerCount)
    
    
  }
}
