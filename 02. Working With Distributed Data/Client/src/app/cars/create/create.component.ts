import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from 'ngx-strongly-typed-forms';
import { Car } from '../cars.model';
import { Validators } from '@angular/forms';
import { CarsService } from '../cars.service';
import { ToastrService } from 'ngx-toastr';
import { Category } from '../category.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  carForm: FormGroup<Car>;
  categories: Array<Category>
  constructor(private fb: FormBuilder, private carsService: CarsService, public toastr: ToastrService, private router: Router) {
    this.carsService.getCategories().subscribe(res => {
      this.categories = res;
    })
   }

  ngOnInit(): void {
    this.carForm = this.fb.group<Car>({
      manufacturer: [null, Validators.required],
      model: [null, Validators.required],
      category: [null, Validators.required],
      imageUrl: [null, Validators.required],
      pricePerDay: [null, Validators.required],
      hasClimateControl: [null, Validators.required],
      numberOfSeats: [null, Validators.required],
      transmissionType: [null, Validators.required],
    })
  }


  create() {
    this.carsService.createCar(this.carForm.value).subscribe(res => {
      this.toastr.success("Success");
      this.router.navigate(['cars', 'mine'])
    })
  }

}
