export interface Animal {
  id: number;
  name: string;
  type: AnimalType;
  typeName: string;
  userName: string;
  created: string;
}

export enum AnimalType {
  Cat = 0,
  Dog,
  Rat,
  Tiger
}
