function digPow(n, p){

  const number = n.toString().split('').map(Number);
  let result = 0;

  for (let i = 0; i < number.length; i++) {
    
    result += Math.pow(number[i], p);
    p++;
  }

  if (result % n === 0){
    return result / n;
  }

  return -1;

}