import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { CarsModule } from './cars/cars.module';
import { SharedModule } from './shared/shared.module';
import { DealersModule } from './dealers/dealers.module'

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    AuthenticationModule,
    CarsModule,
    DealersModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
