from flask import Flask, request, jsonify
import psycopg2

app = Flask(__name__)

def get_db_connection():
    return psycopg2.connect(
        host='db',
        database='users_db',
        user='user',
        password='password'
    )

@app.route('/vaccinationRecord', methods=['GET'])
def get_user():
    user_id = request.args.get('user')
    ##response if no user id provided
    if not user_id:
        return jsonify({'error': 'No User ID Provided'}), 400
    
    ##first check if user is a valid user
    conn = get_db_connection()
    cur = conn.cursor()
    cur.execute('SELECT user_id, name FROM accounts WHERE user_id = %s', (user_id,))
    records = cur.fetchall()
    cur.close()
    conn.close()
    ##if records implies the user was found in accounts table, therefore valid user
    if records:
        ##now check if records for that user exist
        conn = get_db_connection()
        cur = conn.cursor()
        cur.execute('SELECT type, vacc_date FROM vaccinations WHERE user_id = %s', (user_id,))
        records = cur.fetchall()
        cur.close()
        conn.close()
        ##record exist for that user, returning them
        if records:
            result = [{'type': i[0], 'date': i[1]} for i in records]
            return jsonify({'records': result})
        ##no records found
        else:
            return jsonify({'error': 'Records Not Found For That User'}),404

    ##no recrods found, therefore not user id
    else:
        return jsonify({'error': 'User Not Found'}), 404


if __name__ == '__main__':
    app.run(host='0.0.0.0', port = 5002)

