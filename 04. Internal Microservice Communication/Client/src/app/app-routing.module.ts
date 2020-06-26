import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./authentication/authentication-routing.module').then(m => m.AuthenticationRoutingModule)
  },
  {
    path: 'cars',
    loadChildren: () => import('./cars/cars-routing.module').then(m => m.CarsRoutingModule)
  },
  {
    path: 'dealers',
    loadChildren: () => import('./dealers/dealers-routing.module').then(m => m.DealersRoutingModule)
  },
  {
    path: '',
    loadChildren: () => import('./shared/shared-routing.module').then(m => m.SharedRoutingModule)
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
