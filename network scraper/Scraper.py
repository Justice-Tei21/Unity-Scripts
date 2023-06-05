import requests
from bs4 import BeautifulSoup
import webbrowser


search = input()
url = "https://www.google.com/search?q="+search


headers = {
	'Accept' : '*/*',
	'Accept-Language': 'en-US,en;q=0.5',
	'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.82',
}

info =requests.get(url,headers=headers,)
soup = BeautifulSoup(info.text,"html.parser")

listofurls = {}

urls = soup.find(id = "search")

out = urls.find_all("a")
for i in range(4):
	listofurls[i]= out[i]["href"]
	print(out[i]["href"])


print("")


toopen = listofurls[int(input())]
webbrowser.open(toopen)