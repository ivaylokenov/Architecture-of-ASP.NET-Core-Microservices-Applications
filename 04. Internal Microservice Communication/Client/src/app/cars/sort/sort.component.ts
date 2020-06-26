import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Sort } from './sort.model';
import { FormGroup, FormBuilder } from 'ngx-strongly-typed-forms';
import { Validators } from '@angular/forms';
import { CarsService } from '../cars.service';
import { Car } from '../cars.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sort',
  templateUrl: './sort.component.html',
  styleUrls: ['./sort.component.css']
})
export class SortComponent implements OnInit {
  sortForm: FormGroup<Sort>;
  @Output('emitter') emitter = new EventEmitter<Array<Car>>();

  constructor(private fb: FormBuilder, private carService: CarsService, private router: Router) { }

  ngOnInit(): void {
    this.sortForm = this.fb.group<Sort>({
      sortBy: ['', Validators.required],
      order: [''],
    })
  }

  sort() {
    this.carService.sort(this.getQueryUrl()).subscribe(cars => {
      this.emitter.emit(cars)
    })
  }

  getQueryUrl() {
    const params = new URLSearchParams();
    const formValue = this.sortForm.value; // this.form should be a FormGroup
    console.log(this.sortForm.value)
    for (const key in formValue) {
      if (!formValue[key]) {
        continue;
      }
      params.append(key, formValue[key]);
    }
    var query = params.toString()
    if (this.router.url.includes('mine')) {
      query = '/mine?' + params
    }
    else {
      query = '?' + params
    }
    return query;
  }

}
