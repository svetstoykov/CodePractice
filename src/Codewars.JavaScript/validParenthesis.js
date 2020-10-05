function validParentheses(parens) {
  
    const parensArr = parens.split('');
  
    for (let i = 0; i < parensArr.length; i++) {
      if (parensArr[i] + parensArr[i + 1] === '()') {
        parensArr.splice(i, 2);
        i = -1;
      }
    }
  
    if (parensArr.length > 0) return false;
  
    return true;
  }