function highestRank(arr) {
    const result = arr.reduce((acc, num) => {
      acc.hasOwnProperty(num) ? (acc[num] += 1) : (acc[num] = 0);
  
      return acc;
    }, {});
  
    console.log(result);
  
    let sort = Object.keys(result).sort((a, b) => {
      return result[b] - result[a] || Number(b) - Number(a);
    });
  
    return Number(sort[0]);
  }