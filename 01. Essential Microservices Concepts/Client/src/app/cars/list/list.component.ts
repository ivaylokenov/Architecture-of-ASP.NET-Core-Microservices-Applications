import { Component, OnInit } from '@angular/core';
import { CarsService } from '../cars.service';
import { Car } from '../cars.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  cars: Array<Car>;
  id: string;
  category = null;
  constructor(private carsService: CarsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.fetchCars()

  }

  fetchCars() {
    this.carsService.getCars().subscribe(cars => {
      this.cars = cars['carAds'];
    })
  }

  assignCars(event) {
    this.cars = event['carAds'];
  }

}
