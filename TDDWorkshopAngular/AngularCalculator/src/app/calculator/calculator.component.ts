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

    return this.validateInputsArray(splitNum);
  }

  private validateInputsArray(splitNum: string[]) {
    let result = 0;
    for(var i=0; i< splitNum.length; i++) {
      const parsedVal = parseInt(splitNum[i]);
      if (!isNaN(parsedVal)) {
        result += parsedVal;
      } else {
        throw new Error(splitNum[i] + ' is not a valid number');
      }
      
    }
    return result;
  }
}

