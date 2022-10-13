function longestConsec(strarr, k) {
  if (strarr.length === 0 || k > strarr.length || k <= 0) {
    return '';
  }

  let longest = 0;
  let result = [];

  for (let i = 0; i < strarr.length; i++) {
    const consecString = strarr.slice(i, i + k);

    const length = consecString.map(el => el.length).reduce((a, b) => a + b);

    if (length > longest) {
      longest = length;
      result = consecString;
    }
  }

  return result.join('');
}