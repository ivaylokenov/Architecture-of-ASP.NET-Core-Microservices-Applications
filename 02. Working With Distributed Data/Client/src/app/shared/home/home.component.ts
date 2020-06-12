import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/cars/category.model';
import { CarsService } from 'src/app/cars/cars.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  categories: Array<Category>;
  constructor(private carsService: CarsService, private router: Router) { }

  ngOnInit(): void {
    this.carsService.getCategories().subscribe(res => {
      this.categories = res;
    })
  }

  goToCars(id) {
    this.router.navigate(['cars'], { queryParams: { category: id } });
  }

}
