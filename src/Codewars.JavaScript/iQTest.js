function iqTest(numbers) {
    numbers = numbers.split(' ').map(Number);
  
    let result = numbers.filter(num => num % 2 === 0);
  
    if (result.length > 1) {
      result = numbers.filter(num => num % 2 !== 0);
    }
  
    return numbers.indexOf(result[0]) + 1;
  }