import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CarsService } from 'src/app/cars/cars.service';
import { Car } from 'src/app/cars/cars.model';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {
  @Input('queryString') queryString;
  @Output('emitter') emitter = new EventEmitter<Array<Car>>();
  constructor(private carService: CarsService) { }

  ngOnInit(): void {
  }

  changePage() {
    this.carService.search(this.queryString).subscribe(res => {
      this.emitter.emit(res);
    })
  }

}
