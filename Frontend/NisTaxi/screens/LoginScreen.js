import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, ScrollView, Image, Button, Pressable, TextInput } from 'react-native';
import { useContext } from 'react';
import { AuthContext } from '../context/AuthContext';
import { useState } from 'react';
import Toast from 'react-native-toast-message';

export default function LoginScreen({ navigation }) {
  const[phoneNumber, setPhoneNumber] = useState("");
  const[taxiLicence, setTaxiLicence] = useState("");
  const[errors, setErrors] = useState({});

  const validateForm = () => {
    let errors = {};

    if(!phoneNumber) errors.phoneNumber = "Username is required";
    if(!taxiLicence) errors.taxiLicence = "Password is required";

    setErrors(errors);

    return Object.keys(errors).length === 0;
  }

  const { login } = useContext(AuthContext);

  return (
    <View style={styles.container}>
      <View style={styles.scrollView}>
      <View style={{flex: 1, justifyContent: 'center', alignItems: 'center'}}>
        <Text style={styles.loginText}>Prijavi se</Text>
      </View>
    
      <View style={{flex: 1, justifyContent: 'center', alignItems: 'start'}}>
        <Text style={styles.fieldText}>Broj telefona</Text>
        <TextInput style={styles.inputField} placeholder='+3816XXXXXXX' value={phoneNumber} onChangeText={text => setPhoneNumber(text)}/>
        {
          errors.username && <Text style={{color: 'red'}}>{errors.username}</Text>
        }
      </View>
      <View style={{flex: 1, justifyContent: 'center', alignItems: 'start', marginTop:10}}>
        <Text style={styles.fieldText}>Broj taksi dozvole</Text>
        <TextInput style={styles.inputField} placeholder='XXXXX' value={taxiLicence} onChangeText={text => setTaxiLicence(text)}/>
        {
          errors.password && <Text style={{color: 'red'}}>{errors.password}</Text>
        }
      </View>
      <View style={{flex: 1, justifyContent: 'center', alignItems: 'center'}}>
        <Pressable style={styles.loginBtn} onPress={() => login(phoneNumber, taxiLicence)}>
          <Text style={styles.loginBtnText}>Prijavi se</Text>
        </Pressable>
      </View>
        <StatusBar style="auto" />
      </View>
      <Toast />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    width: '100%',
    height: '100%',
    backgroundColor: '#fff',
    paddingLeft: 20,
    paddingRight: 20,
    alignItems: 'center',
    justifyContent: 'center',
  },
  scrollView:{
    width: '100%',
    height:400,
  },
  root: {
    justifyContent: 'center',
    alignItems: 'center',
  },
  loginText:{
    fontSize: 34,
    fontWeight: '700',
  },
  fieldText:{
    fontSize: 15,
    fontWeight: '400',
    color: '#8F8F8F',
  },
  loginBtn:{
    marginTop: 40,
    alignItems: 'center',
    justifyContent: 'center',
    paddingVertical: 15,
    paddingHorizontal: 32,
    width: '100%',
    borderRadius: 6,
    elevation: 4,
    backgroundColor: '#F5BF24',
  },
  loginBtnText:{
    fontSize: 18,
    fontWeight: '700',
  },
  inputField:{
    height: 60,
    marginTop: 10,
    paddingLeft:10,
    backgroundColor: '#EDEEEC',
    borderRadius: 6,
  }
});
