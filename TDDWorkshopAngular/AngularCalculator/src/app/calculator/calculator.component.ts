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
      return parseInt(input);
    }

    const splitNum = input.split(',');
    if (splitNum.length > 2) throw new Error('Only summing 2 inputs is permitted');
    const result = parseInt(splitNum[0]) + parseInt(splitNum[1]);
    return result;
  }
}

