import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Animal, AnimalType } from '../models/animal';

@Component({
  selector: 'app-add-animal',
  templateUrl: './add-animal.component.html'
})

export class AddAnimalComponent {
  animalForm;
  http;
  baseUrl;
  message;
  animalTypes = AnimalType;
  public animalOptions = [];

  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private formBuilder: FormBuilder) {

    this.animalForm = this.formBuilder.group({
      name: '',
      type: AnimalType.Cat,
    });

    this.http = http;
    this.baseUrl = baseUrl;

    this.animalOptions = Object.keys(this.animalTypes).filter(f => !isNaN(Number(f)));
  }

  onSubmit(animalData) {
    animalData.type = + animalData.type;

    this.http.post(this.baseUrl + 'api/animals', animalData).subscribe(result => {
      console.log(result);
    }, error => {
      console.log(error);
      this.message = error.error.title;
    });

    this.animalForm.reset();

    this.message = 'Your pet has been submitted';
    console.warn('Your pet has been submitted', animalData);
  }
}
