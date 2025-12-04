import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../project-service/project.service';
import { CommonModule } from '@angular/common';

interface MenuItem {
  CategoryId: number;
  CategoryName: string;
  ItemId: number;
  Code: string;
  ItemName: string;
  ItemDescription: string;
  ImgUrl: string;
  IsAvailable: boolean;
  Price: number;
  Currency: string;
}

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
  imports: [
    CommonModule,
  ]
})
export class MenuComponent implements OnInit {

  menuData: MenuItem[] = [];
  loading: boolean = false;
  error: string = '';

  constructor(private projectService: ProjectService) { }

  ngOnInit(): void {
    this.loadMenu();
  }

  loadMenu() {
    this.loading = true;
    this.error = '';
    this.projectService.getMenu().subscribe({
      next: (res) => {
        if (res.status === 1) {
          this.menuData = res.data;
        } else {
          this.error = res.message || 'Lỗi khi tải menu';
        }
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Lỗi kết nối API';
        console.error(err);
        this.loading = false;
      }
    });
  }
}
