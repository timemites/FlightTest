import { Time } from "@angular/common";

export class Flight {
    FlightId:number;
    FlightNo:string;
    StartTime:Time;
    EndTime:Time;
    PassengerCapacity:number;
    DepartureCity:string;
    ArrivalCity:string;
}
