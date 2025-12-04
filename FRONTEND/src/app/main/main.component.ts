import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],

  imports: [
    FormsModule,
  ]
})
export class MainComponent implements OnInit {
  people: number = 2;
  date!: string;
  time!: string;

  constructor(private router: Router) {}

  ngOnInit() {}

  goMenu(){
    this.router.navigate(['/menu']);
  }

  goRestaurantMap(){
    this.router.navigate(['/restaurant-map']);
  }

  goBooking(){
    const bookingData = {
      people: this.people,
      date: this.date,
      time: this.time,
    };

    this.router.navigate(['/booking'], { state: bookingData });
  }
}
