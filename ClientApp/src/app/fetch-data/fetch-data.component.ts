import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Animal, AnimalType } from '../models/animal';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public animals: Animal[];
  animalTypes = AnimalType;
  public animalOptions = [];


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.animalOptions = Object.keys(AnimalType).filter(f => !isNaN(Number(f)));

    http.get<Animal[]>(baseUrl + 'api/animals').subscribe(result => {
      this.animals = result;
    }, error => console.error(error));
  }

  filterUser(animal: Animal) {
    return !user.age >= 18
  }
}
