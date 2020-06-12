import { Component, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from 'ngx-strongly-typed-forms';
import { Search } from './search.model';
import { Validators } from '@angular/forms';
import { CarsService } from '../cars.service';
import { Category } from '../category.model';
import { EventEmitter } from '@angular/core';
import { Car } from '../cars.model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  searchForm: FormGroup<Search>
  categories: Array<Category>;
  category = null;
  @Output('emitter') emitter = new EventEmitter<Array<Car>>();
  constructor(private fb: FormBuilder, private carService: CarsService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.searchForm = this.fb.group<Search>({
      manufacturer: ['', Validators.required],
      dealer: [''],
      category: [this.category, Validators.required],
      minPricePerDay: [null, Validators.required],
      maxPricePerDay: [null, Validators.required],
    })
    this.route.queryParams.subscribe(params => {
      this.category = params['category'];
      this.searchForm.patchValue({category: this.category})
      console.log(this.searchForm)
      this.search()
  });
    this.carService.getCategories().subscribe(res => {
      this.categories = res
    })
  }

  search() {
    var queryString = this.getQueryUrl();
    this.carService.search(queryString).subscribe(cars => {
        this.emitter.emit(cars)
    })
  }

  getQueryUrl() {
    const params = new URLSearchParams();
    const formValue = this.searchForm.value; // this.form should be a FormGroup
    console.log(this.searchForm.value)
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
