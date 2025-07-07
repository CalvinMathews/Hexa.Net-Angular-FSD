import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CourseCatalogComponent } from './course-catlog/course-catlog.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CourseCatalogComponent],  
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {}