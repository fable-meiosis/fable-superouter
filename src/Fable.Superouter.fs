// ts2fable 0.6.1
module rec Fable.Superouter

open System
open Fable.Core
open Fable.Import.JS

let [<Import("PatternToken","module")>] patternToken: PatternToken.IExports = jsNative
let [<Import("URLToken","module")>] uRLToken: URLToken.IExports = jsNative
let [<Import("Valid","module")>] valid: Valid.IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract tokenizePattern: pattern: string -> obj option
    abstract tokenizeURL: patternTokens: string * theirURL: string -> obj option
    abstract ``type``: typename: string * cases: obj option -> unit
    abstract ``type$safe``: typeName: string * cases: obj option -> obj option

module PatternToken =
    let [<Import("Error","module/PatternToken")>] error: Error.IExports = jsNative
    let [<Import("groupValidations","module/PatternToken")>] groupValidations: GroupValidations.IExports = jsNative
    let [<Import("singleValidations","module/PatternToken")>] singleValidations: SingleValidations.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        abstract name: string
        abstract Part: value: obj option -> unit
        abstract Path: value: obj option -> unit
        abstract Variadic: value: obj option -> unit
        // { Path, Part, Variadic }
        abstract fold: obj option -> unit
        abstract groupSpecificity: tokens: string -> unit
        abstract infer: segment: string -> unit
        abstract isVariadic: o: obj option -> unit
        abstract specificity: token: string -> unit
        abstract toPattern: xs: obj option -> unit
        abstract toString: x: obj option -> unit
        abstract validate: [<ParamArray>] args: ResizeArray<obj option> -> unit
        abstract validateGroup: [<ParamArray>] args: ResizeArray<obj option> -> unit

    module Error =

        type [<AllowNullLiteral>] IExports =
            abstract name: string
            abstract DuplicateDef: [<ParamArray>] args: ResizeArray<obj option> -> unit
            abstract DuplicatePart: [<ParamArray>] args: ResizeArray<obj option> -> unit
            abstract VariadicCount: [<ParamArray>] args: ResizeArray<obj option> -> unit
            abstract VariadicPosition: [<ParamArray>] args: ResizeArray<obj option> -> unit

    module GroupValidations =

        type [<AllowNullLiteral>] IExports =
            abstract duplicateDef: allTokensPairs: obj option -> obj option

    module SingleValidations =

        type [<AllowNullLiteral>] IExports =
            abstract duplicatePart: tokens: obj option -> obj option
            abstract variadicCount: tokens: obj option -> obj option
            abstract variadicPosition: tokens: obj option -> obj option

module URLToken =
    let [<Import("Error","module/URLToken")>] error: Error.IExports = jsNative
    let [<Import("transforms","module/URLToken")>] transforms: Transforms.IExports = jsNative
    let [<Import("validations","module/URLToken")>] validations: Validations.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        abstract ExcessSegment: segment: obj option -> unit
        // { key, value }
        abstract Part: obj option -> unit
        abstract Path: value: obj option -> unit
        // { expected, actual }
        abstract Unmatched: obj option -> unit
        // { key, value }
        abstract Variadic: obj option -> unit
        // { Path, Part, Variadic, Unmatched, ExcessSegment }
        abstract fold: obj option -> unit
        abstract fromPattern: o: obj option -> unit
        abstract isVariadic: o: obj option -> unit
        abstract toArgs: xs: obj option -> unit
        abstract toString: x: obj option -> unit
        abstract toURL: xs: obj option -> unit
        abstract transform: url: string * urlTokens: obj option * patternTokens: obj option -> obj option
        abstract validate: [<ParamArray>] args: ResizeArray<obj option> -> unit

    module Error =

        type [<AllowNullLiteral>] IExports =
            abstract ExcessPattern: [<ParamArray>] args: ResizeArray<obj option> -> unit
            abstract ExcessSegment: [<ParamArray>] args: ResizeArray<obj option> -> unit
            abstract UnmatchedPaths: [<ParamArray>] args: ResizeArray<obj option> -> unit

    module Transforms =

        type [<AllowNullLiteral>] IExports =
            abstract collectVariadics: url: string -> obj option

    module Validations =

        type [<AllowNullLiteral>] IExports =
            abstract excessPatterns: patternTokens: obj option -> obj option
            abstract excessSegments: patternTokens: obj option -> obj option
            abstract unmatchedPaths: patternTokens: obj option -> obj option

module Valid =

    type [<AllowNullLiteral>] IExports =
        abstract name: string
        abstract N: value: obj option -> unit
        abstract Y: value: obj option -> unit
        abstract bifold: N: obj option * Y: obj option -> unit
        // { Y, N }
        abstract fold: obj option -> unit
        abstract map: f: obj option -> unit

