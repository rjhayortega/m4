from flask import Flask
import subprocess
from flask import json
from flask_cors import CORS 

app = Flask(__name__)

cors = CORS(app)
@app.route('/')
def hello():
    # import subproces
     CMD = "mono ./m1.exe 1"
     output = subprocess.check_output(CMD,shell=True)
     lst = []
     for char in output:
         lst.append(char) 
     tst =  ''.join(lst).split('\n')
     #return jsonify(
      #  data = tst
    #)
     print tst
     return str(tst)


@app.route('/add/<email>')
def addVisit(email):
    # import subproces
     CMD = "mono ./m1.exe "+email
     output = subprocess.check_output(CMD,shell=True)
     lst = []
     for char in output:
         lst.append(char) 
     tst =  ''.join(lst).split('\n')
     #return jsonify(
      #  data = tst
    #)
     print tst
     return str(tst)


    

if __name__=='__main__':
    app.run('0.0.0.0')
