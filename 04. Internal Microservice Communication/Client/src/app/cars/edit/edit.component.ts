import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from '../cars.model';
import { FormGroup, FormBuilder } from 'ngx-strongly-typed-forms';
import { Validators } from '@angular/forms';
import { CarsService } from '../cars.service';
import { ToastrService } from 'ngx-toastr';
import { Category } from '../category.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  id: string;
  car: Car;
  carForm: FormGroup<Car>;
  categories: Array<Category>;
  constructor(private route: ActivatedRoute, 
    private fb: FormBuilder, 
    private carService: CarsService, 
    private router: Router,
    public toastr: ToastrService) { 
    this.id = this.route.snapshot.paramMap.get('id');
    this.carForm = this.fb.group<Car>({
      manufacturer: ['', Validators.required],
      model: ['', Validators.required],
      category: [0, Validators.required],
      imageUrl: ['', Validators.required],
      pricePerDay: [0, Validators.required],
      hasClimateControl: [false, Validators.required],
      numberOfSeats: [0, Validators.required],
      transmissionType: [0, Validators.required],
    })
  }

  async ngOnInit(): Promise<void> {
    await this.fetchCategories()
    this.fetchCar()
  }

  mapCategory(car) {
    var category = this.categories.filter(x => x.name == car.category)[0]
    this.carForm.patchValue({category: category.id})
  } 

  mapClimateControl(car) {
    var hasClimateControl = new Array({hasClimateControl: false, text: 'No'}, {hasClimateControl: true, text: 'Yes'})
    .filter(x => x.hasClimateControl == car.hasClimateControl)[0]
    this.carForm.patchValue({hasClimateControl: hasClimateControl.hasClimateControl})
  }

  mapTransmisionType(car) {
    var transmissionType = new Array({id: 1, text: 'Manual'}, {id: 2, text: 'Automatic'})
    .filter(x => x.text == car.transmissionType)[0]
    this.carForm.patchValue({transmissionType: transmissionType.id})
  }

  mapDropDownData(car) {
    this.mapCategory(car);
    this.mapClimateControl(car);
    this.mapTransmisionType(car);
  }
  
  fetchCar() {
    this.carService.getCar(this.id).subscribe(car => {
      this.carForm = this.fb.group<Car>({
        manufacturer: [car.manufacturer, Validators.required],
        model: [car.model, Validators.required],
        category: [car.category, Validators.required],
        imageUrl: [car.imageUrl, Validators.required],
        pricePerDay: [car.pricePerDay, Validators.required],
        hasClimateControl: [car.hasClimateControl, Validators.required],
        numberOfSeats: [car.numberOfSeats, Validators.required],
        transmissionType: [car.transmissionType, Validators.required],
      })
      this.mapDropDownData(car);
      console.log(this.carForm.value)
    })
  }

  edit() {
    this.carService.editCar(this.id, this.carForm.value).subscribe(res => {
      this.router.navigate(['cars']);
      this.toastr.success("Success")
    })
  }

  fetchCategories() {
    this.carService.getCategories().subscribe(res => {
      this.categories = res;
    })
  }

  get imageUrl() {
    return this.carForm.get('imageUrl').value;
  }

}
