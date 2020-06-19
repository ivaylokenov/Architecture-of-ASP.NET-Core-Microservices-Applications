import { Component, OnInit } from '@angular/core';
import { Car } from '../cars.model';
import { CarsService } from '../cars.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  car: Car;
  id: string;
  constructor(private carService: CarsService, private route: ActivatedRoute) { 
    this.id = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
    this.carService.getCar(this.id).subscribe(car => {
      this.car = car;
    });
  }
}
