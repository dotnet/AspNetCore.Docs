#!/bin/bash

set -e

# This script runs the .NET CLI, invoking the what's new global tool
#     $1 is the <github.repository_owner>
#     $2 is the <github.repository>
#     $3 is the savedir

declare -r STARTDATE=$(date "+%F" -d "$(date +'%Y-%m-01') -1 month");
declare -r ENDDATE=$(date "+%F" -d "$STARTDATE +1 month -1 day");

echo "From $STARTDATE to $ENDDATE"

while getopts o:r:s: option
do
case "${option}"
in
o) OWNER=${OPTARG};;
r) REPO=${OPTARG};;
s) SAVEDIR=${OPTARG};;
esac
done

dotnet whatsnew \
    --owner $OWNER \
    --repo $REPO \
    --startdate $STARTDATE \
    --enddate $ENDDATE \
    --savedir $SAVEDIR
