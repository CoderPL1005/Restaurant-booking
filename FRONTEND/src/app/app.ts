import { Component, signal } from '@angular/core';
import { NavigationEnd, RouterOutlet, ɵEmptyOutletComponent } from '@angular/router';
import { Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgIf],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('FRONTEND');
  showFooter = true;
  isLoggedIn = false;

  constructor(private router: Router) {
    this.updateFooter(this.router.url);

    // lắng nghe thay đổi route
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        this.updateFooter(event.urlAfterRedirects);
      });
  }

  private updateFooter(url: string) {
    const currentUrl = url.split('?')[0];
     this.showFooter = currentUrl === '/';
  }

  goRegister() {
    this.router.navigate(['/register']);
  }

  goLogin() {
    this.router.navigate(['/login']);
  }

  goLogout() {
    this.isLoggedIn = false;
    this.router.navigate(['/']);
  }

  login() {
    this.isLoggedIn = true;
  }

  goMain(){
    this.router.navigate(['/']);
  }
}
