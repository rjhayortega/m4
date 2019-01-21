from flask import Flask
import subprocess
from flask_cors import CORS, cross_origin
app = Flask(__name__)

@app.route('/')
def hello():
    # import subproces
     CMD = "mono ./m3/m1.exe"
     output = subprocess.check_output(CMD,shell=True)
     lst = []
     for char in output:
         lst.append(char) 
     print ''.join(lst).split('\n')
     return "ASDSDA"

if __name__=='__main__':
    app.run('0.0.0.0')
