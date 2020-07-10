import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { ViewComponent } from './view/view.component';
import { CarsRoutingModule } from './cars-routing.module';
import { SharedModule } from '../shared/shared.module';
import { SearchComponent } from './search/search.component';
import { SortComponent } from './sort/sort.component';
import { DealerCarsComponent } from './dealer-cars/dealer-cars.component';

@NgModule({
  declarations: [ListComponent, CreateComponent, EditComponent, ViewComponent, SearchComponent, SortComponent, DealerCarsComponent],
  imports: [
    CommonModule,
    SharedModule,
    CarsRoutingModule,
  ],
  exports: [ListComponent, CreateComponent, EditComponent, ViewComponent, SearchComponent, DealerCarsComponent]
})
export class CarsModule { }
