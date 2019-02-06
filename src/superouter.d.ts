export function tokenizePattern(pattern: string): any;

export function tokenizeURL(patternTokens: string, theirURL: string): any;

export function type(typename: string, cases: any): void;

export function type$safe(typeName: string, cases: any): any;

export namespace PatternToken {
  const name: string;

  function Part(value: any): void;

  function Path(value: any): void;

  function Variadic(value: any): void;

  function fold({ Path, Part, Variadic }: any): void;

  function groupSpecificity(tokens: string): void;

  function infer(segment: string): void;

  function isVariadic(o: any): void;

  function specificity(token: string): void;

  function toPattern(xs: any): void;

  function toString(x: any): void;

  function validate(...args: any[]): void;

  function validateGroup(...args: any[]): void;

  namespace Error {
    const name: string;

    function DuplicateDef(...args: any[]): void;

    function DuplicatePart(...args: any[]): void;

    function VariadicCount(...args: any[]): void;

    function VariadicPosition(...args: any[]): void;
  }

  namespace groupValidations {
    function duplicateDef(allTokensPairs: any): any;
  }

  namespace singleValidations {
    function duplicatePart(tokens: any): any;

    function variadicCount(tokens: any): any;

    function variadicPosition(tokens: any): any;
  }
}

export namespace URLToken {
  function ExcessSegment(segment: any): void;

  function Part({ key, value }: any): void;

  function Path(value: any): void;

  function Unmatched({ expected, actual }: any): void;

  function Variadic({ key, value }: any): void;

  function fold({ Path, Part, Variadic, Unmatched, ExcessSegment }: any): void;

  function fromPattern(o: any): void;

  function isVariadic(o: any): void;

  function toArgs(xs: any): void;

  function toString(x: any): void;

  function toURL(xs: any): void;

  function transform(url: string, urlTokens: any, patternTokens: any): any;

  function validate(...args: any[]): void;

  namespace Error {
    function ExcessPattern(...args: any[]): void;

    function ExcessSegment(...args: any[]): void;

    function UnmatchedPaths(...args: any[]): void;
  }

  namespace transforms {
    function collectVariadics(url: string): any;
  }

  namespace validations {
    function excessPatterns(patternTokens: any): any;

    function excessSegments(patternTokens: any): any;

    function unmatchedPaths(patternTokens: any): any;
  }
}

export namespace Valid {
  const name: string;

  function N(value: any): void;

  function Y(value: any): void;

  function bifold(N: any, Y: any): void;

  function fold({ Y, N }: any): void;

  function map(f: any): void;
}
