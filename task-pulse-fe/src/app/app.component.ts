import { Component, inject, OnInit, signal } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { TasksService } from './services/tasks.service';
import { Task } from './models/task.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ReactiveFormsModule, InputTextModule, ButtonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  private readonly tasksService = inject(TasksService);

  tasks = signal<Task[]>([]);

  ngOnInit(): void {
    this.tasksService.getTasks().subscribe({
      next: (tasks) => {
        this.tasks.set(tasks);
      }
    });
  }

  addTask(input: HTMLInputElement) {
    const title = input.value.trim();
    if (title === '') return;

    const task = {} as Task;
    task.title = title;
    this.tasksService.addTask(task).subscribe({
      next: (task) => {
        this.tasks.update((tasks) => [...tasks, task]);
        input.value = '';
      }
    });
  }
}
