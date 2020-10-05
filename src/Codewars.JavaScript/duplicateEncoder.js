function duplicateEncode(word){
    let result = '';
      word = word.toLowerCase();
  
      for (let el of word) {
  
          let repeats = 0;
  
          for (let i = 0; i < word.length; i++) {
  
              if (word[i] === el) {
                  repeats++;
              }
  
          }
  
          if (repeats > 1) {
              result += ')';
          } else {
              result += '(';
          }
  
      }
  
      return result
  }

  console.log(duplicateEncode("Success"));