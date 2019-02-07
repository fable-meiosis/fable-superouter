// ts2fable 0.6.1
module rec Fable.Superouter

open System
open Fable.Core
open Fable.Import.JS

let [<Import("PatternToken","module")>] patternToken: PatternToken.IExports = jsNative
let [<Import("URLToken","module")>] uRLToken: URLToken.IExports = jsNative
let [<Import("Valid","module")>] valid: Valid.IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract tokenizePattern: pattern: string -> obj
    abstract tokenizeURL: patternTokens: string * theirURL: string -> obj
    abstract ``type``: typename: string * cases: obj  -> unit
    abstract ``type$safe``: typeName: string * cases: obj -> obj

module PatternToken =
    let [<Import("Error","module/PatternToken")>] error: Error.IExports = jsNative
    let [<Import("groupValidations","module/PatternToken")>] groupValidations: GroupValidations.IExports = jsNative
    let [<Import("singleValidations","module/PatternToken")>] singleValidations: SingleValidations.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        abstract name: string
        abstract Part: value: obj -> unit
        abstract Path: value: obj -> unit
        abstract Variadic: value: obj -> unit
        // { Path, Part, Variadic }
        abstract fold: obj -> unit
        abstract groupSpecificity: tokens: string -> unit
        abstract infer: segment: string -> unit
        abstract isVariadic: o: obj -> unit
        abstract specificity: token: string -> unit
        abstract toPattern: xs: obj -> unit
        abstract toString: x: obj -> unit
        abstract validate: [<ParamArray>] args: ResizeArray<obj> -> unit
        abstract validateGroup: [<ParamArray>] args: ResizeArray<obj> -> unit

    module Error =

        type [<AllowNullLiteral>] IExports =
            abstract name: string
            abstract DuplicateDef: [<ParamArray>] args: ResizeArray<obj> -> unit
            abstract DuplicatePart: [<ParamArray>] args: ResizeArray<obj> -> unit
            abstract VariadicCount: [<ParamArray>] args: ResizeArray<obj> -> unit
            abstract VariadicPosition: [<ParamArray>] args: ResizeArray<obj> -> unit

    module GroupValidations =

        type [<AllowNullLiteral>] IExports =
            abstract duplicateDef: allTokensPairs: obj -> obj

    module SingleValidations =

        type [<AllowNullLiteral>] IExports =
            abstract duplicatePart: tokens: obj -> obj
            abstract variadicCount: tokens: obj -> obj
            abstract variadicPosition: tokens: obj -> obj

module URLToken =
    let [<Import("Error","module/URLToken")>] error: Error.IExports = jsNative
    let [<Import("transforms","module/URLToken")>] transforms: Transforms.IExports = jsNative
    let [<Import("validations","module/URLToken")>] validations: Validations.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        abstract ExcessSegment: segment: obj -> unit
        // { key, value }
        abstract Part: obj -> unit
        abstract Path: value: obj -> unit
        // { expected, actual }
        abstract Unmatched: obj -> unit
        // { key, value }
        abstract Variadic: obj -> unit
        // { Path, Part, Variadic, Unmatched, ExcessSegment }
        abstract fold: obj -> unit
        abstract fromPattern: o: obj -> unit
        abstract isVariadic: o: obj -> unit
        abstract toArgs: xs: obj -> unit
        abstract toString: x: obj -> unit
        abstract toURL: xs: obj -> unit
        abstract transform: url: string * urlTokens: obj * patternTokens: obj -> obj
        abstract validate: [<ParamArray>] args: ResizeArray<obj> -> unit

    module Error =

        type [<AllowNullLiteral>] IExports =
            abstract ExcessPattern: [<ParamArray>] args: ResizeArray<obj> -> unit
            abstract ExcessSegment: [<ParamArray>] args: ResizeArray<obj> -> unit
            abstract UnmatchedPaths: [<ParamArray>] args: ResizeArray<obj> -> unit

    module Transforms =

        type [<AllowNullLiteral>] IExports =
            abstract collectVariadics: url: string -> obj

    module Validations =

        type [<AllowNullLiteral>] IExports =
            abstract excessPatterns: patternTokens: obj -> obj
            abstract excessSegments: patternTokens: obj -> obj
            abstract unmatchedPaths: patternTokens: obj -> obj

module Valid =

    type [<AllowNullLiteral>] IExports =
        abstract name: string
        abstract N: value: obj -> unit
        abstract Y: value: obj -> unit
        abstract bifold: N: obj * Y: obj -> unit
        // { Y, N }
        abstract fold: obj -> unit
        abstract map: f: obj -> unit

