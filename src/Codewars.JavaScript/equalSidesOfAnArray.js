function findEvenIndex(arr) {
    const resultArr = [];
    for (let i = 0; i < arr.length; i++) {
      let leftSide = 0;
      let rightSide = 0;
  
      for (let j = 0; j < i; j++) {
        leftSide += arr[j];
      }
  
      for (let k = arr.length - 1; k > i; k--) {
        rightSide += arr[k];
      }
  
      if (leftSide === rightSide) {
        resultArr.push(i);
      }
    }
  
    let result = 0;
  
    if (resultArr.length > 0) {
      result = Math.min(resultArr);
    } else {
      result = -1;
    }
  
    return result;
  }