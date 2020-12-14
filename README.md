# SolrDecoder

## About SolrDecoder
SolrDecoder is a tool to decode compressed base64 strings present in CS files associated with the SUNBURST backdoor. The tool takes in a CS file that contains an encoded payload and provides a decoded CS file and a CSV containing a list of encoded and the corresponding decoded strings. 

## Usage

 _____       _     ______                   _
/  ___|     | |    |  _  \                 | |
\ `--.  ___ | |_ __| | | |___  ___ ___   __| | ___ _ __
 `--. \/ _ \| | '__| | | / _ \/ __/ _ \ / _` |/ _ \ '__|
/\__/ / (_) | | |  | |/ /  __/ (_| (_) | (_| |  __/ |
\____/ \___/|_|_|  |___/ \___|\___\___/ \__,_|\___|_|


  -i, --input     Required. Full path of .cs file that contains the payload

  -o, --output    Required. Output path

  --help          Display this help screen.

  --version       Display version information.
