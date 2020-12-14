# SolrDecoder

## About SolrDecoder
SolrDecoder is a tool to decode compressed base64 strings present in .cs files associated with the SUNBURST backdoor. It looks for content between "OrionImprovementBusinessLayer.ZipHelper.Unzip("/*content*/") and attempts to decode the content. The tool takes in a .cs file that contains an encoded payload and provides a decoded CS file and a CSV containing a list of encoded and the corresponding decoded strings. 

## Usage

SolrDecoder.exe -i backdoor.cs -o C:\temp\output

  -i, --input     Required. Full path of .cs file that contains the payload

  -o, --output    Required. Output path

  --help          Display this help screen.

  --version       Display version information.
