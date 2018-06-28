% The following are just for warmup
%[0-9]+                  printf("dDigit "); //yylval=atoi(yytext); return NUMBER;
%[0-9]+\.[0-9]+          printf("dFloat "); //yylval=atoi(yytext); return NUMBER;
%(([0-9]+)|([0-9]+\.[0-9]+))[eE][+-]?([0-9]+) printf("sFloat "); //yylval=atoi(yytext); return NUMBER;
%0(b|B)[01]+             printf("bitInt ");
%0(o|O)[0-7]+            printf("octInt ");
%0(x|X)[0-9a-fA-F]+      printf("hexInt ");
%\\[bnrt\\\"\'afv]       printf("escapeChar ");
%\\u([0-9a-fA-F]{4})     printf("escapeChar ");
%\\U([0-9a-fA-F]{8})|[0-9]{3} printf("escapeChar ");
% Here starts the real tokens
