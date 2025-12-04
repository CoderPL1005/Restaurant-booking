import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css'],
})
export class BookingComponent implements OnInit {
  people!: number;
  date!: string;
  time!: string;

  constructor(private router: Router) {
    const state = this.router.getCurrentNavigation()?.extras.state;
    if (state) {
      this.people = state['people'];
      this.date = state['date'];
      this.time = state['time'];
    }
  }

  ngOnInit() {
    console.log("Check: " + this.people + " " + this.date + " " + this.time);
  }
}
