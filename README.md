# SolrDecoder

## About SolrDecoder
SolrDecoder is a tool to decode compressed base64 strings present in CS files associated with the SUNBURST backdoor. The tool takes in a CS file that contains an encoded payload and provides a decoded CS file and a CSV containing a list of encoded and the corresponding decoded strings. 

## Usage

SolrDecoder.exe -i backdoor.cs -o C:\temp\output

  -i, --input     Required. Full path of .cs file that contains the payload

  -o, --output    Required. Output path

  --help          Display this help screen.

  --version       Display version information.
