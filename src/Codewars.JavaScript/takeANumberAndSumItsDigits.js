function sumDigPow(a, b) {
    const result = [];
  
    for (let i = a; i < b; i++) {
      const numSplit = String(i)
        .split('')
        .map(Number)
        .reduce((x, y, index) => x + Math.pow(y, index + 1));
  
      if (i === numSplit) result.push(i);
    }
  
    return result;
  }