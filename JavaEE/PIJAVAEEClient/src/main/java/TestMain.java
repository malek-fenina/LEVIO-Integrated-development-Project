import java.util.ArrayList;
import java.util.List;

import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import model.Project;

import services.IconsumerRemote;

public class TestMain {

	public static void main(String[] args) throws NamingException {
		List<Project> ls = new ArrayList<Project>();
		String jndiName = "PIJAVAEE-ear/PIJAVAEE-ejb/ProjectConsum!services.IconsumerRemote";
		Context context = new InitialContext();
		IconsumerRemote service = (IconsumerRemote) context.lookup(jndiName);
		ls=service.testConsume();
		
		//service.deleteProjectById(Project.getIdProject());
		}

}

