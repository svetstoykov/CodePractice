function solution(list) {
    let consec = [];
  
    const result = list.reduce((acc, num, i, arr) => {
      const nextNum = arr[i + 1];
  
      if (num + 1 === nextNum) {
        consec.push(num);
          } else if(consec.length < 2 && i > 0 && consec.length > 0) {
        acc.push(arr[i - 1]);
        acc.push(num);
        consec = [];
      } else if (consec.length >= 2) {
        consec.push(num);
        acc.push(consec);
        consec = [];
      } else {
        acc.push(num);
      }
  
      return acc;
      }, []);
      
  
      let final = result.reduce((acc, el) =>{
  
          const type = typeof el;
  
          if(type === 'object'){
              acc.push(`${el[0]}-${el[el.length - 1]}`);
          } else {
              acc.push(el);
          }
  
          return acc;
  
      },[])
  
      return final.join(',');
  
  }