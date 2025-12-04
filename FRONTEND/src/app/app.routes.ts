import { Routes } from '@angular/router';
import { MainComponent } from './main/main.component';
import { RegisterComponent } from './project/register/register.component';
import { LoginComponent } from './project/login/login.component';
import { MenuComponent } from './project/menu/menu.component';
import { RestaurantMapComponent } from './project/restaurant-map/restaurant-map.component';
import { BookingComponent } from './project/booking/booking.component';

export const routes: Routes = [
    {path: '', component: MainComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'login', component:LoginComponent},
    {path: 'menu', component: MenuComponent},
    {path: 'restaurant-map', component: RestaurantMapComponent},
    {path: 'booking', component: BookingComponent}
];
