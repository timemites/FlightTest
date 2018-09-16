import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import {
  MatFormFieldModule,
  MatInputModule,
  MatButtonModule,
  MatCheckboxModule,
  MatCardModule,
  MatRadioModule,
  MatNativeDateModule,
  MatDatepickerModule,
  MatSortModule
} from '@angular/material';

import { MatTableModule } from "@angular/material/table";
import { LoadingModule, ANIMATION_TYPES } from 'ngx-loading';

import { AppComponent } from './app.component';
import { FlightsComponent } from './acme/flights/flights.component';
import { AcmeComponent } from './acme/acme.component';
import { BookingComponent } from './acme/booking/booking.component';
import { FilterdataPipe } from './filterdata.pipe';
import {DataTableModule} from "angular-6-datatable";

const appRoutes: Routes = [
  { path: 'Flight', component: FlightsComponent },
  { path: 'Booking',      component: BookingComponent },
  { path: '**', redirectTo: '/Flight', pathMatch: 'full' }
];
@NgModule({
  declarations: [
    AppComponent,
    FlightsComponent,
    AcmeComponent,
    BookingComponent,
    FilterdataPipe,

  ],
  imports: [
    BrowserModule,
    DataTableModule,
    FormsModule, 
    ReactiveFormsModule ,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatTableModule,
    MatSortModule,
    MatButtonModule,
    MatInputModule,
    MatCheckboxModule,
    MatCardModule,
    MatRadioModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatSortModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    HttpClientModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    ),
    LoadingModule.forRoot({
      animationType: ANIMATION_TYPES.threeBounce,
      backdropBackgroundColour: 'rgba(0,0,0,0.2)', 
      backdropBorderRadius: '4px',
      fullScreenBackdrop:true,
      primaryColour: '#17a2b8', 
      secondaryColour: '#ffffff', 
      tertiaryColour: '#ffffff'
  })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
