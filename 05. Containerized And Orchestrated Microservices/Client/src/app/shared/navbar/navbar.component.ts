import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CarsService } from 'src/app/cars/cars.service';
import { Category } from 'src/app/cars/category.model';
import { NotificationsService } from '../notifications.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  token: string;
  constructor(
    private router: Router,
    private notificationsService: NotificationsService) { }

  ngOnInit(): void {
    this.getToken();
    this.notificationsService.subscribe();
  }

  getToken() {
    this.token = localStorage.getItem('token')
  }

  route(param) {
    console.log(param)
    this.router.navigate([param])
  }

  chanheNav(event) {
    console.log(event)
  }

  logout() {
    localStorage.removeItem('token')
    this.getToken()
    this.router.navigate(['auth'])
  }
}
