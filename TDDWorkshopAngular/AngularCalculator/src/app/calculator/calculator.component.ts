import { Component } from '@angular/core';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent {

  add(input: string): number {

    if (input === "") return 0;

    if (input.indexOf(",") == -1) {
      return parseInt(input, 10);
    }
    else{
      
    }



    return 0;
  }
}

